import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastrService {

  constructor(private toastr:ToastrService) { }

  success(message:string) {
    this.toastr.success(message);
  }

  error(message:string) {
    this.toastr.error(message);
  }

  warning(message:string) {
    this.toastr.warning(message);
  }
}
