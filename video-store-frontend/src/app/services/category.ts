import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private readonly categoriesEndpoint = '/categories';

  constructor(private httpClient: HttpClient) {}

  getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(this.categoriesEndpoint);
  }

  getCategoryById(categoryId: number): Observable<Category> {
    return this.httpClient.get<Category>(`${this.categoriesEndpoint}/${categoryId}`);
  }

  createCategory(categoryName: string): Observable<Category> {
    return this.httpClient.post<Category>(this.categoriesEndpoint, { name: categoryName });
  }
}
