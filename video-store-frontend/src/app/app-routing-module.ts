import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: 'home',
    loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'upload',
    loadChildren: () => import('./components/upload/upload.module').then(m => m.UploadModule)
  },
  {
    path: 'streaming/:id',
    loadChildren: () => import('./components/streaming/streaming.module').then(m => m.StreamingModule)
  },
  { path: '**', redirectTo: '/home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
