import { Component } from '@angular/core';
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


