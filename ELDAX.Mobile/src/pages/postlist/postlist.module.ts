import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { PostlistPage } from './postlist';

@NgModule({
  declarations: [
    PostlistPage,
  ],
  imports: [
    IonicPageModule.forChild(PostlistPage),
  ],
})
export class PostlistPageModule {}
