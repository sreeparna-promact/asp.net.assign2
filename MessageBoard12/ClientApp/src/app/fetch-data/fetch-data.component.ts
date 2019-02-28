import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { MessageData } from '../messagedata/MessageData';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})



  

  
 


export class fetchData  {
  

  public data: Array<MessageData>;

  constructor(private http: HttpClient) {
    this.http = http;
  }

  public GetMessage() {

    return this.http.request('https://localhost:44353/'+'api/MessageData');
  }

  public add(payload) {
    return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
  }

  public remove(payload) {
     });
  }

  public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, { headers: this.headers });
  }
}



