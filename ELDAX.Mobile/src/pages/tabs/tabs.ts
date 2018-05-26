import { Component, ViewChild  } from '@angular/core';
import { Tabs } from 'ionic-angular';
import { AboutPage } from '../about/about';
import { ContactPage } from '../contact/contact';
import { HomePage } from '../home/home';
import { LoginPage } from '../login/login';
import { TabsPagesArray } from '../../interfaces/tabsPage';
import { Pageges } from  '../pages'

@Component({
  templateUrl: 'tabs.html',
  providers: [Pageges ]
})
export class TabsPage {
  public TabsPages: TabsPagesArray;
  constructor( Pageges: Pageges ) {
    this.TabsPages = Pageges.PageItems;
  }
}


