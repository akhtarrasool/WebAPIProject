import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { log } from 'util';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html'
})
export class TrainingComponent {
 
  public training: TrainingData;
  public http: HttpClient;
  public baseUrl: string;
  public textMessage = 'Test text';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public postTrainingData() {
    this.textMessage = 'Updated Text';
    this.createTraining();

    this.http.get<string>(this.baseUrl + 'api/Training/Get').subscribe(result => {
      this.textMessage = result;
      log(result);
    }, error => console.error(error));

    this.http.post<string>(this.baseUrl + 'api/Training/Post', this.training).subscribe(result => {
      log(result);
    }, error => console.error(error));
  }

  public createTraining() {
    let training: TrainingData = {
      trainingName: 'Test training from JS',
      startDate: new Date(2019,08,08),
      endDate: new Date(2019, 08, 08)

    };
  }
}

interface TrainingData {
  trainingName: string;
  startDate: Date;
  endDate: Date;
}
