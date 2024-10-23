
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Home from './components/Home'; 
import BookList from './components/BookList';
import AddReservation from './components/AddReservation';
import ReservationList from './components/ReservationList';

const App = () => {
    return (
        <Router>
            <div>
                <nav>
                    <ul>
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li>
                            <Link to="/books">View Books</Link>
                        </li>
                        {/*<li>*/}
                        {/*    <Link to="/add-reservation">Reserve a Book</Link>*/}
                        {/*</li>*/}
                        <li>
                            <Link to="/reservations">My Reservations</Link>
                        </li>
                    </ul>
                </nav>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/books" element={<BookList />} />
                    <Route path="/add-reservation" element={<AddReservation />} />
                    <Route path="/reservations" element={<ReservationList />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
