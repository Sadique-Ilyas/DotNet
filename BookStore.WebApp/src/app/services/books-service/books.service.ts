import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from 'src/app/books/books.component';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  baseURL: string = "https://localhost:7185/api/Book/";

  constructor(private http: HttpClient) { }

  get(): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseURL);
  }

  getById(id: number): Observable<Book> {
    return this.http.get<Book>(this.baseURL+id);
  }

  post(book: Book): Observable<any> {
    return this.http.post(this.baseURL, book, { responseType: "text" });
  }

  put(book: Book): Observable<any> {
    return this.http.put(this.baseURL+book.id, book, { responseType: "text" });
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.baseURL+id, { responseType: "text" });
  }
}
