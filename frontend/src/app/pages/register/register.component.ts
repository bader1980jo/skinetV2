import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  msg = null;
  user: User = new User();

  constructor(private auth: AuthService, private router: Router) {

  }

  registerUser() {
    this.auth.register(this.user).subscribe({
      next: (res) => {
        alert(res.message);
        this.router.navigate(['login']);
      },
      error: (err) => {
        alert(err?.error.message)
      }
    });
  }
}
