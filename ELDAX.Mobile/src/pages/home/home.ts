import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Inject } from '@angular/core';
import { ApiControllersInfo } from '../../services/apiControllersInfo'
import { EldaxLocalStorage }  from '../../services/localStorage';
import { ControllersInfo, ControllersInfoArray } from '../../interfaces/controllersInfo';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html',
  providers: [ ApiControllersInfo, EldaxLocalStorage ]
})
export class HomePage {  
  constructor(
    protected navCtrl: NavController,
    protected apiControllersInfo: ApiControllersInfo,
    protected eldaxLocalStorage: EldaxLocalStorage, ) {
      this.setClientVersion();
      this.SetApiControllersInfo();
    }

  private setClientVersion(): void {
    this.apiControllersInfo.GetClientVersion()
        .then(result => 
          this.clientVersion = result.clientVersion
        );
  }

  private SetApiControllersInfo(): void{
    this.apiControllersInfo.GetApiControllersInfo()
        .then(result => 
          this.controllersInfos = result
        );
  }

  public controllersInfos: ControllersInfoArray; 
  public clientVersion: string = "";
  public tapCounter: any = 0;
  
  buttonTapped() {
    this.tapCounter++;
  }
  
  reset() {
    this.tapCounter--;
  }


}
