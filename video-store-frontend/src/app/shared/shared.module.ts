import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TruncatePipe } from './pipes/truncate.pipe';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner';

@NgModule({
  declarations: [
    TruncatePipe,
    LoadingSpinnerComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CommonModule,
    TruncatePipe,
    LoadingSpinnerComponent
  ]
})
export class SharedModule { }
