import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';

import { factsProvider } from './providers/facts-url.provider';
import { FactsComponent } from './components/facts/facts.component';
import { RandomFactComponent } from './components/random-fact/random-fact.component';
import { RandomFromCategoryComponent } from './components/random-from-category/random-from-category.component';
import { SearchFactComponent } from './components/search-fact/search-fact.component';

const components = [
  FactsComponent,
  RandomFactComponent,
  RandomFromCategoryComponent,
  SearchFactComponent
];

const angularImports = [
  CommonModule,
  HttpClientModule,
  ReactiveFormsModule
];
const material = [
  MatCardModule,
  MatButtonModule,
  MatSelectModule,
  MatFormFieldModule,
  MatDividerModule,
  MatInputModule
];

const providers = [factsProvider];

@NgModule({
  declarations: [components],
  imports: [angularImports, material],
  providers: [providers]
})
export class ChuckDomainModule { }
