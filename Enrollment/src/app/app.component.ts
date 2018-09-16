// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-root',
//   templateUrl: './app.component.html',
//   styleUrls: ['./app.component.css']
// })
// export class AppComponent {
//   title = 'Enrollment';
// }






import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent
{
  public states: GetStates[];
  public cities: GetCity[];
  public constituencies: GetConstituency[];
  public wards: GetWard[];
  baseUrl: string;
  searchName: string = "";
  fullName: string = "";
  stateId: number = 0;
  cityId: number = 0;
  consId: number = 0;
  wardId: number = 0;
  fatherName: string = "";
  dob: string = "";
  email: string = "";
  phone: string = "";

 

  constructor(private http: HttpClient) {
    http.get<GetStates[]>('http://localhost:54772/api/values/GetStates').subscribe(result => {
      this.states = result;
      console.log(result);
    }, error => console.error(error));
  }
  
  GetCity(stateId) {
    alert(stateId);
    var data = stateId;
    this.http.get<GetCity[]>('http://localhost:54772/api/values/GetCity?StateId='+ data).subscribe(result => {
      this.cities = result;
      console.log(result);
    }, error => console.error(error));
   
  }

  GetConstituency(cityId) {
    alert(cityId);
    var data = cityId;
    this.http.get<GetConstituency[]>('http://localhost:54772/api/values/GetConstituency?cityId=' + data).subscribe(result => {
      this.constituencies = result;
      console.log(result);
    }, error => console.error(error));

  }
  GetWardNoDetails(wardNo) {

  }

  GetWardNo(constituencyId) {
    alert(constituencyId);
    var data = constituencyId;
    this.http.get<GetWard[]>('http://localhost:54772/api/values/getWard?constituencyId=' + data).subscribe(result => {
      this.wards = result;
      console.log(result);
    }, error => console.error(error));

  }

  SubmitMe() {
   
    console.log(this.stateId);
    console.log(this.fullName);
    console.log(this.consId);
    console.log(this.fatherName);
    console.log(this.dob);
    console.log(this.cityId);
    console.log(this.wardId);
    console.log(this.phone);
    console.log(this.email);
    var data = new Object();
    data["StateId"] = this.stateId;

    this.http.get<any>('http://localhost:54772/api/values/GetEnrollmentNumber?StateId=' + this.stateId + '&CityId=' + this.cityId + '&ConstituencyId=' + this.consId + '&WardNumberId=' + this.wardId + '&EnrollerName=' + this.fullName + '&Email=' + this.email + '&DOB=' + this.dob + '&PhoneNumber=' + this.phone + '&FatherName=' + this.fatherName).subscribe(result => {
      //this.cities = result;
      console.log(result);
      alert("Data saved successfully!! Please check your email for enrollment number.");
    }, error => console.error(error));
  }
}




interface GetStates {
  StateId: number;
  StateName: string;
  
}
interface GetCity {
  CityId: number;
  CityName: string;

}

interface GetConstituency {
  ConstituencyId: number;
  ConstituencyName: string;

}
interface GetWard {
  WardNumberId: number;
  WardNumber: string;

}

