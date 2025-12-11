import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { Streaming } from './streaming';

const routes: Routes = [
  { path: '', component: Streaming }
];

@NgModule({
  declarations: [Streaming],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class StreamingModule { }
