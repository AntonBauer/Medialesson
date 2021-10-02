import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { factsProvider } from './providers/facts-url.provider';

const angularImports = [CommonModule, HttpClientModule];
const providers = [factsProvider];

@NgModule({
  declarations: [],
  imports: [angularImports],
  providers: [providers]
})
export class ChuckDomainModule { }
