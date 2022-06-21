import React, {useState, useEffect} from "react";
import BookProvider from "../providers/bookProviders";
import AuthorProvider from "../providers/authorProvider";
import GenreProvider from "../providers/genreProvider";

export default function ModalEdit({book, setOpenModalEdit, loadBook}){
    const [currentBook, setCurrentBook] = useState(book)
    const [authors, setAuthors] = useState([])
    const [genres, setGenres] = useState([])

    useEffect(()=>{
        AuthorProvider.getAuthors().then(
            result => {
                setAuthors(result)
            }
        )
        GenreProvider.getGenres().then(
            result => {
                setGenres(result)
            }
        )
    },[])


    function close(e){
        if(e.target.className === 'close-container'){
            setOpenModalEdit(false)
        }
    }


    function changeName(e){
        setCurrentBook({
            ...currentBook, name : e.target.value
        })
    }


    function changeYear(e){
        setCurrentBook({
            ...currentBook, year : Number(e.target.value)
        })
    }

    function changeAuthor(e){
        setCurrentBook({
            ...currentBook, authorId : Number(e.target.value)
        })
    }

    function changeGenre(e){
        setCurrentBook({
            ...currentBook, genreId : Number(e.target.value)
        })
    }

    async function save(){
        if(currentBook.name === ''){
            alert('Заполните название книги')
        }
        else{
            let result = null;
            if(currentBook.id !== null){
                result = await BookProvider.editBook(currentBook)
            }
            else{
                result = await BookProvider.addBook(currentBook)
            }

            if(result){
                await loadBook()
                setOpenModalEdit(false)
            }
            else{
                alert('Произошла ошибка')
            }
        }
        
    }

    return(
        <div onClick={e=>{close(e)}} className="close-container">
            <div className="modal-container">
                <div className="modal-content">
                    <label>Название</label>
                    <input type='text' defaultValue={currentBook.name} onChange={(e)=> changeName(e)}/>
                    <label>Автор</label>
                    <select onChange={(e)=>{changeAuthor(e)}} value={currentBook.authorId}>
                        {   authors &&
                            authors.map(author=>{
                                return <option key={author.id}  value={author.id}>{author.name}</option>
                            })
                        }
                    </select>
                    <label>Жанр</label>
                    <select onChange={(e)=>{changeGenre(e)}} value={currentBook.genreId}>
                        {   genres &&
                            genres.map(genre=>{
                                return <option key={genre.id}  value={genre.id}>{genre.name}</option>
                            })
                        }
                    </select>
                    <label>Год</label>
                    <input type='number' defaultValue={currentBook.year} onChange={(e)=> changeYear(e)}/>

                    <input type="button" onClick={()=>{save()}} value="Сохранить"/>
                </div>
            </div>
        </div>
    )
}