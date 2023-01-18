import { AfterViewChecked, Component, OnInit,  } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { StorageService } from 'src/app/services/storage/storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, AfterViewChecked{
   user: any;
   admin: boolean = false;
   isLoggedIn = false;
  
  constructor(
    private router: Router,
    private storageService: StorageService,
    private alertsService: AlertService
  ) {
  }

  ngOnInit(): void {
    this.user = this.storageService.getUser();
    this.isLoggedIn = this.storageService.isLoggedIn();
    
    if(this.user === undefined){
      this.admin = false;
    }
    else{
      this.admin = true;
    }
  }

  ngAfterViewChecked(): void {
    this.isLoggedIn = this.storageService.isLoggedIn();
    
    if(!this.isLoggedIn){
      this.admin = false;
    }
  }

  login(){
    this.router.navigate(['/login']);
  }

  logout(): any{
    this.storageService.clean();
    this.admin = false;
    this.alertsService.oneSuccessMessage('Logout efetuado com sucesso.');
    window.location.reload();
  }
}
