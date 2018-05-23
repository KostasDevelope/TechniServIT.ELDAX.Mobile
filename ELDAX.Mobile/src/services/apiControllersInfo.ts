
import { Injectable } from '@angular/core';
import { EldaxLocalStorage }  from './localStorage';
import {  config }  from '../config';

export class ApiControllersInfo{
    constructor(protected eldaxLocalStorage: EldaxLocalStorage) {}

}