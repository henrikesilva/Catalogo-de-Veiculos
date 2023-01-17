import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/services/storage/storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
   public user: any;
   isLoggedIn = false;
  
  constructor(
    private router: Router,
    private storageService: StorageService
  ) {
  }

  ngOnInit(): void {
    this.user = this.storageService.getUser();
  }

  login(){
    this.router.navigate(['/login']);
  }

  logout(): any{
    this.storageService.clean();
    if(this.user){
      return this.router.navigate(['']);
    }
  }
}
