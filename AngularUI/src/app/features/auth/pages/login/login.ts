import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { Auth } from '@features/auth/services/auth';
import { Separator } from "app/shared/separator/separator";

@Component({
  selector: 'hf-login',
  imports: [ReactiveFormsModule, RouterLink, Separator],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  constructor(private authService: Auth) {};

  loginForm = new FormGroup({
    username: new FormControl('', { nonNullable: true }),
    password: new FormControl('', { nonNullable: true })
  });

  onSubmit(): void{
    if (this.loginForm.invalid) return;

    this.authService.login(this.loginForm.getRawValue()).subscribe({
      next: (response) => {
        console.log('Connexion réussie', response);
      },
      error: (err) => {
        console.log('Échec de la connexion', err);
      }
    })
  }

  loginWithGoogle(): void {
    window.addEventListener('message', (event) => {
      if (event.origin !== 'http://localhost:4200') return;

      const token = event.data.token;
      if (token) {
        // stockage du token
      }
    })

    const popup = window.open(
      'http://localhost:5148/api/User/google-login',
      'google-auth',
      'width=500,height=600'
    );
  }
}
