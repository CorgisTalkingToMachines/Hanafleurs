import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { RouterLink, RouterLinkActive } from '@angular/router';
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
}
