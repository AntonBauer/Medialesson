import { FactsComponent } from './modules/chuck-domain/components/facts/facts.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'facts', component: FactsComponent },
  { path: '**', redirectTo: 'facts' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
