import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { IProperty } from '../model/iProperty';
import { Property } from '../model/property';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private http: HttpClient) { }

  getProperty(id:number) {
    return this.getAllProperties().pipe(
      map(propertyArray => {
        return propertyArray.find(p=> p.Id === id)
      })
    )
  }

  getAllProperties(sellRent?:number): Observable<IProperty[]> {
    return this.http.get('data/properties.json').pipe(
      map((data: any) => {
        const propertiesArray: Array<IProperty> = [];
        const localProperties = localStorage.getItem('newProp')
        if(localProperties) {
          const properties = JSON.parse(localProperties)
          for(const id in properties) {
            if(sellRent) {
              if (properties.hasOwnProperty(id) && properties[id].SellRent === sellRent) {
                propertiesArray.push(properties[id]);
              } else {
                propertiesArray.push(properties[id]);
              }
            }
          }
        }

        for(const id in data) {
          if(sellRent) {
            if (data.hasOwnProperty(id) && data[id].SellRent === sellRent) {
              propertiesArray.push(data[id]);
            }
          } else {
            propertiesArray.push(data[id]);
          }
        }
        return propertiesArray;
      })
    );
  }

  addProperty(property:Property) {
    let newProp = [property]

    // Add new property in array if new property already exist in local storage
    const prop = localStorage.getItem('newProp')
    if(prop) {
      newProp = [property,
                    ...JSON.parse(prop)
      ]
    }
    localStorage.setItem('newProp',JSON.stringify(newProp))
  }

  newPropId() {
    const previousID = localStorage.getItem('PID')
    if(previousID) {
      localStorage.setItem('PID',String(+previousID + 1));
      return +previousID+1;
    } else {
      localStorage.setItem('PID','101');
      return 101
    }
  }
}
