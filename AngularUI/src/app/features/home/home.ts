import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'hf-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {
  private urlTestEndPointRole = "http://localhost:5148/api/User/test";

  constructor(private http: HttpClient){};

  OnButtonClick(): void {
    this.http.get(this.urlTestEndPointRole)
    .subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
