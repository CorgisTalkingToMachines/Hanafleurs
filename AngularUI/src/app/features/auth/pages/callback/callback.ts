import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'hf-callback',
  imports: [],
  templateUrl: './callback.html',
  styleUrl: './callback.scss',
})
export class Callback implements OnInit {
  constructor(private route: ActivatedRoute) {};

  ngOnInit(): void {
    const token = this.route.snapshot.queryParamMap.get('token');

    if (token && window.opener ) {
      window.opener.postMessage({ token }, 'http://localhost:4200');
    }

    window.close();
  }
}

