import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Auth } from '@features/auth/services/auth';

@Component({
  selector: 'hf-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  user = {
    username: '',
    email: '',
    password: ''
  };

  constructor(private authService: Auth) {}

  onSubmit(form: NgForm): void {
    if (form.invalid) return;

    this.authService.register(this.user).subscribe({
      next: (response) => {
        console.log('Inscription réussie', response);
      },
      error: (err) => {
        console.error('Erreur lors de l\'inscription', err);
      }
    });
  }
}
