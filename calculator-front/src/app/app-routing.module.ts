import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalculatorComponent } from './components/calculator/calculator.component';
import { LoginComponent } from './components/login/login.component';
const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'calculate',
    component: CalculatorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
