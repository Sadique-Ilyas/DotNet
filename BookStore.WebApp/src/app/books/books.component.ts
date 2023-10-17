import { Component, OnInit } from '@angular/core';
import { BooksService } from '../services/books-service/books.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {

  books?: Book[];
  book: Book = new Book("", Number.NaN);

  constructor(private booksService: BooksService) {
    // Called first time before the ngOnInit()
  }

  ngOnInit() {
    // Called after the constructor and called  after the first ngOnChanges()
    this.getBooks();
  }

  //#region Reactive Form

  form = new FormGroup({
    "id": new FormControl(this.book.id, Validators.required),
    "name": new FormControl(this.book.name, Validators.required),
    "price": new FormControl(this.book.price, Validators.required)
  });

  saveForm() {
    if(this.form.controls.id.value == 0) {
      this.addBook();
    }
    else {
      this.updateBook();
    }
  }

  addBook() {
    this.book = new Book(this.form.controls.name.value!, this.form.controls.price.value!, this.form.controls.id.value!);
    this.booksService.post(this.book).subscribe(response => {
       console.log(response);
       this.getBooks();
       this.form.reset();
    });    
  }

  //#endregion

  getBooks() {
    this.booksService.get().subscribe(response =>{
       this.books = response;
    });
  }

  getBookById(id: number) {
    this.booksService.getById(id).subscribe(response =>{
       this.book = response;
    });
  }

  // addBook(form: any) {
  //   this.book = new Book(form.name, form.price);
  //   console.log(this.book);
  //   this.booksService.post(this.book).subscribe(response => {
  //      console.log(response);
  //      this.getBooks();
  //   });    
  // }

  updateBook() {
    this.book = new Book(this.form.controls.name.value!, this.form.controls.price.value!, this.form.controls.id.value!);
    // console.log("ID: "+id);
    this.booksService.put(this.book).subscribe(response => {
      console.log(response);
      this.getBooks();
      this.form.reset();
    });
  }

  deleteBook(id: number) {
    this.booksService.delete(id).subscribe(response => {
      console.log(response);
      this.getBooks();
    });
  }

}

export class Book {
  constructor(public name: string, public price: number, public id: number=0) {}
}
