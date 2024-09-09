import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PropertyDetailResolverService implements Resolve<Property | null> {

  constructor(private housingService: HousingService,private router:Router) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Property | null> {
      const propId = route.params['id'];
      return this.housingService.getProperty(+propId).pipe(
        map((property: Property | undefined) => property ? property : null),  // Return null if property is undefined
        catchError(() => {
          this.router.navigate(['/'])
          return of(null);  // In case of error, return null
        })
      );
  }
}
