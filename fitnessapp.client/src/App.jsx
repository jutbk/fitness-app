// File: fitnessapp.client/src/App.jsx
import React from 'react';
import Header from './components/Header';
import MembreList from './components/MembreList';
import AbonnementList from './components/AbonnementList';
import Footer from './components/Footer';
import './App.css';

const App = () => {
    return (
        <div id="root">
            <Header />
            <MembreList />
            <AbonnementList />
            <Footer />
        </div>
    );
};

export default App;