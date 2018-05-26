import { Injectable } from '@angular/core';
import { Tabs } from 'ionic-angular';
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
        TabIcon: "home"
      },
      {
        Root: HomePage,
        TabTitle: "Home",
        TabIcon: "home"
      },
      {
        Root: AboutPage,
        TabTitle: "About",
        TabIcon: "information-circle"
      },
      {
        Root: ContactPage,
        TabTitle: "Contact Eldax",
        TabIcon: "contacts"
      }
    ];
  }
  constructor() {
    this.InitTabPages();
  }
}
