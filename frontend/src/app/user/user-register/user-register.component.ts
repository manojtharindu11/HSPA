import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/model/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {
  registrationForm!: FormGroup;
  user!:User;

  constructor(private fb:FormBuilder,private auth:AuthService,private toastr:ToastrService) {}

  ngOnInit(): void {


    //Other way to create reactive form
      // this.registrationForm = new FormGroup( {
      //   userName: new FormControl(null,Validators.required),
      //   email: new FormControl(null,[Validators.required,Validators.email]),
      //   password: new FormControl(null,[Validators.required,Validators.minLength(8)]),
      //   confirmPassword: new FormControl(null,[Validators.required]),
      //   mobile: new FormControl(null,[Validators.required,Validators.maxLength(10)])
      // },{ validators:this.passwordMatchingValidator()})

      this.createRegistrationForm()

  }

  createRegistrationForm() {
    this.registrationForm = this.fb.group({
      userName: [null,Validators.required],
      email: [null,[Validators.required,Validators.email]],
      password: [null,[Validators.required,Validators.minLength(8)]],
      confirmPassword: [null,[Validators.required]],
      mobile: [null,[Validators.required,Validators.maxLength(10)]]
    },
    {
      validators: this.passwordMatchingValidator()
    }
  )
  }

 // Custom validator to check if password and confirmPassword match
 passwordMatchingValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: boolean } | null => {
    const formGroup = control as FormGroup;
    const password = formGroup.get('password')?.value;
    const confirmPassword = formGroup.get('confirmPassword')?.value;

    if (password && confirmPassword && password !== confirmPassword) {
      return { notmatched: true };
    }
    return null;
  };
}

  // Getter methods for all form control
  get userName() {
    return this.registrationForm.get('userName') as FormControl;
  }

  get email() {
    return this.registrationForm.get('email') as FormControl;
  }

  get password() {
    return this.registrationForm.get('password') as FormControl;
  }

  get confirmPassword() {
    return this.registrationForm.get('confirmPassword') as FormControl;
  }

  get mobile() {
    return this.registrationForm.get('mobile') as FormControl;
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      this.auth.registerUser(this.userData()).subscribe({
        next:() => {
          this.registrationForm.reset();
          this.toastr.success("Congrats, You are successfully registered!")
        }
      })
    } else {
      this.registrationForm.markAllAsTouched();
      this.toastr.error("Kindly provide the required field!")
    }

  }

  userData(): User {
    return this.user = {
      userName: this.userName.value,
      email: this.email.value,
      password: this.password.value,
      mobile:this.mobile.value
    }
  }


}
