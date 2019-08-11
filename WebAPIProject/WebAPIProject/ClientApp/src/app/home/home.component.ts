import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { log } from 'util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public training: TrainingData;
  public http: HttpClient;
  public baseUrl: string;
  public message: string;
  public daysMessage: string;
  public messageClass: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

  }

  onSubmit(training: TrainingData) {

    this.daysMessage = '';
    this.message = '';
    this.messageClass = 'text-success';

    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
    this.http.post<any>(this.baseUrl + 'api/Training/Post', training, { headers }).subscribe(status => { 
      console.log(status);
      this.message = status.result;
      if (status.days >= 0) {
        this.daysMessage = 'Total days :' + status.days;
        this.messageClass = 'text-success';
      }
      else {
        this.messageClass = 'text-danger';
      }
    }, error => {
        console.log(error.error);
        this.messageClass = 'text-danger';
        this.message = error.error.error;
      // check error status code is 500, if so, do some action
    }); 
  }
}


interface TrainingData {
  trainingName: string;
  startDate: Date;
  endDate: Date;
}
