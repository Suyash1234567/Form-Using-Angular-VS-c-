
import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  //HttpClient used to connect Angular to DataBase.

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
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
      if (result == null) {
        alert("Something went wrong in selecting States");
      }
      else {
        this.states = result;
        console.log(result);
      }
    }, error => console.error(error));
  }

  GetCity(stateId) {
    //alert(stateId);
    var data = stateId;
    this.http.get<GetCity[]>('http://localhost:54772/api/values/GetCity?StateId=' + data).subscribe(result => {
      if (result == null) {
        alert("Something went wrong to populate city. On potential reason may be : State ID not available");
      }
      else {
        this.cities = result;
        console.log(result);
      }
    }, error => console.error(error));

  }

  GetConstituency(cityId) {

    //alert(cityId);
    var data = cityId;
    this.http.get<GetConstituency[]>('http://localhost:54772/api/values/GetConstituency?cityId=' + data).subscribe(result => {
      if (result == null) 
      {
        alert("Something went wrong in populating constituency. On potential reason may be : City ID not available");
      }
      else 
      {
        this.constituencies = result;
        console.log(result);
      }
    }, error => console.error(error));

  }
  GetWardNoDetails(wardNo) {

  }

  GetWardNo(constituencyId) {
    //alert(constituencyId);
    var data = constituencyId;
    this.http.get<GetWard[]>('http://localhost:54772/api/values/getWard?constituencyId=' + data).subscribe(result => {
      if (result == null) 
      {
        alert("Something went wrong in populating ward. On potential reason may be : Constituency ID not available");
      }
      else 
      {  
    
    this.wards = result;
      console.log(result);
      }
    }, error => console.error(error));

  }


  SubmitMe() {
    if (this.stateId != 0 && this.cityId != 0 && this.consId != 0 && this.wardId != 0) {
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
    else {
      alert("Ensure all the fields are filled!");
    }
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

