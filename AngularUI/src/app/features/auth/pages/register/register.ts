import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Auth } from '@features/auth/services/auth';
//import { Auth } from 'C:\Users\ta_gu\Git\Hanafleurs\AngularUI\src\app\features\auth\services\auth';

@Component({
  selector: 'hf-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  user = {
    name: '',
    email: '',
    password: ''
  };

  onSubmit(form: NgForm): void {

  }
}
