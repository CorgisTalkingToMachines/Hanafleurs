import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Auth } from '@features/auth/services/auth';
import { Separator } from "app/shared/separator/separator";
import { Router } from '@angular/router';

@Component({
  selector: 'hf-register',
  imports: [FormsModule, Separator],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  user = {
    username: '',
    email: '',
    password: ''
  };

  constructor(private authService: Auth, private router: Router) {}

  onSubmit(form: NgForm): void {
    if (form.invalid) return;

    this.authService.register(this.user).subscribe({
      next: (response) => {
        console.log('Inscription réussie', response);

        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Erreur lors de l\'inscription', err);
      }
    });
  }
}
