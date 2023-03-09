import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  msg=null;
user: User = new User();

constructor(private auth: AuthService, private router: Router){

}

loginUser(){
  this.auth.login(this.user).subscribe({
    next: (res) => {
      alert(res.message)
    },
    error: (err) => {
      alert(err?.error.message)
    }
    
  });
}
}
