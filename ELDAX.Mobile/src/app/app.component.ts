import { Component, ViewChild } from '@angular/core';
import { Platform, Nav, MenuController } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { TabsPage } from '../pages/tabs/tabs';
import { Pageges } from  '../pages/pages'
import { TabsPagesArray } from '../interfaces/tabsPage';

@Component({
  templateUrl: 'app.html',
  providers: [ Pageges ]
})
export class MyApp {
  @ViewChild(Nav) navCtrl: Nav;
  rootPage: any = TabsPage;
  menuPages: TabsPagesArray;

  constructor(platform: Platform, statusBar: StatusBar, splashScreen: SplashScreen,  Pageges: Pageges, public menu: MenuController) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      statusBar.styleDefault();
      splashScreen.hide();
    });
    menu.enable(false);
    this.menuPages = Pageges.PageItems;
  }

  openPage(page) {
    this.navCtrl.setRoot(page.Root, {index: page.Index});
  }

  openMenu() {
    this.menu.open();
  }
}
