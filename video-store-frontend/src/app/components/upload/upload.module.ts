import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';
import { Upload } from './upload';

const routes: Routes = [
  { path: '', component: Upload }
];

@NgModule({
  declarations: [Upload],
  imports: [
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild(routes)
  ]
})
export class UploadModule { }
