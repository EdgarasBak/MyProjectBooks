import React from 'react';
import { Link } from 'react-router-dom';

const Home = () => {
    return (
        <div className="container">
            <h1 className="mt-5">Library Reservation System</h1>
            <div className="mt-5">
                <Link to="/books" className="btn btn-primary mr-3">View Books</Link> {/* Link to books */}
                <Link to="/add-reservation" className="btn btn-secondary">Reserve a Book</Link>
                <Link to="/reservations" className="btn btn-secondary ml-3">View Reservations</Link>
            </div>
        </div>
    );
};

export default Home;
