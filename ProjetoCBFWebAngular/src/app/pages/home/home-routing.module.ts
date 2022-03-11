import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { ImportarTabelaComponent } from '../ImportaTabela/importar-tabela/importar-tabela.component';

const routes: Routes = [
  {path: 'ImportarTabela', component: ImportarTabelaComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
