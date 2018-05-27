import { Injectable } from '@angular/core';
import { AboutPage } from './about/about';
import { ContactPage } from './contact/contact';
import { HomePage } from './home/home';
import { LoginPage } from './login/login';
import { TabsPagesArray } from '../interfaces/tabsPage';

@Injectable()
export class Pageges {
  public PageItems: TabsPagesArray;
  private InitTabPages(): void {
    this.PageItems = [
      {
        Root: LoginPage,
        TabTitle: "Login",
        TabIcon: "home",
        Index: "0"
      },
      {
        Root: HomePage,
        TabTitle: "Home",
        TabIcon: "home",
        Index: "1"
      },
      {
        Root: AboutPage,
        TabTitle: "About",
        TabIcon: "information-circle",
        Index: "2"
      },
      {
        Root: ContactPage,
        TabTitle: "Contact Eldax",
        TabIcon: "contacts",
        Index: "3"
      }
    ];
  }
  constructor() {
    this.InitTabPages();
  }
}
