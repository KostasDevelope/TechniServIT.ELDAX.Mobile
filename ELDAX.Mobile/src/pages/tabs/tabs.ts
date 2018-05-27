import { NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { TabsPagesArray } from '../../interfaces/tabsPage';
import { Pageges } from  '../pages'

@Component({
  templateUrl: 'tabs.html',
  providers: [Pageges ]
})
export class TabsPage {
  public TabsPages: TabsPagesArray;
  index: string;
  constructor( Pageges: Pageges, public navParams: NavParams ) {
    this.TabsPages = Pageges.PageItems;
    this.index = navParams.get('index');
  }
}


