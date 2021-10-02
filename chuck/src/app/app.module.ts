import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app/app.component';
import { ChuckDomainModule } from './modules/chuck-domain/chuck-domain.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const components = [AppComponent];
const angularImports = [BrowserModule];
const appImports = [AppRoutingModule, ChuckDomainModule];

@NgModule({
  declarations: [components],
  imports: [angularImports, appImports, BrowserAnimationsModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
