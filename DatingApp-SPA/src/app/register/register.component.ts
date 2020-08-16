import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // to receive prop from parent comp
  // to send prop for parent comp
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authervice: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authervice.register(this.model).subscribe(() => {
      console.log('Registration successful');
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }



}
