import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllItensPublicSalesComponent } from './all-itens-public-sales/all-itens-public-sales.component';
import { PublicSalesComponentComponent } from './public-sales-component/public-sales-component.component';
import { UsersComponentComponent } from './users-component/users-component.component';

const routes: Routes = [
  {
    path: 'users',
    component: UsersComponentComponent,
  },
  {
    path: 'publicsales',
    component: PublicSalesComponentComponent,
  },
  {
    path: 'allItensPublicSales',
    component: AllItensPublicSalesComponent,
  },
  {
    path: '',
    redirectTo: 'allItensPublicSales',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
