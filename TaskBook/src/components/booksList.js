import React, {useState, useEffect} from "react";
import BookProvider from "../providers/bookProviders";
import ModalEdit from "./modalEdit";
import BookBlank from '../models/bookBlank'

export default function BookList({setAuth}){
    const [books, setBooks] = useState([])
    const [openModalEdit, setOpenModalEdit] = useState(false)
    const [currentBook, setCurrentBook] = useState(null);

    useEffect(()=>{
        loadBook()
    },[])

    async function loadBook(){
        BookProvider.getBooks().then(
            result => {
                setBooks(result)
            }
        )
    }

    function openModalOnEdit(book){
        const bookBlank = new BookBlank(book.id, book.name, book.authorId, book.genreId, book.year)
        setCurrentBook(bookBlank)
        setOpenModalEdit(!openModalEdit)
    }


    function openModalOnCreate(){
        const bookBlank = new BookBlank(null, '', 1, 1, 2000)
        setCurrentBook(bookBlank)
        setOpenModalEdit(!openModalEdit)
    }

    async function removeBooks(){
        const removedBooks = books.filter(book=>book.selected === true)
        if(removedBooks.length === 0){
            alert('Сначала выберите книги')
        }
        else{
            const ids = removedBooks.map(book=> {return book.id})
            const result = await BookProvider.removeBooks(ids)
            if(result){
                await loadBook()
            }
            else{
                alert('Произошла ошибка')
            }
        }
    }
    function logout(){
        localStorage.removeItem('testTaskBookToken')
        setAuth(false)
    }
    return(
        <div className="books-table-container">
            <input className="add-button" type='button' value='Добавить' onClick={()=>{openModalOnCreate()}}/>
            <input onClick={()=>{removeBooks()}} className="delete-button" type='button' value='Удалить'/>
            <input onClick={()=>{logout()}} className="delete-button" type='button' value='Выйти'/>
            {openModalEdit ? <ModalEdit loadBook={loadBook} book={currentBook} setOpenModalEdit={setOpenModalEdit} /> : ''}
            <table>
                <thead>
                    <tr>
                        <td>ID</td>
                        <td>Название</td>
                        <td>Автор</td>
                        <td>Год выпуска</td>
                        <td>Жанр</td>
                    </tr>
                </thead>
                <tbody>
                    {books && books.map((book, index)=> <tr key={index}>
                        <td>{book.id}</td>
                        <td>{book.name}</td>
                        <td>{book.author}</td>
                        <td>{book.year}</td>
                        <td>{book.genre}</td>
                        <td onClick={(e)=>{openModalOnEdit(book)}}>&#x270E;</td>
                        <td><input type="checkbox"  onChange={()=> book.selected = !book.selected} value={book.selected}/></td>
                    </tr>)}
                </tbody>
            </table>
        </div>
    )
}