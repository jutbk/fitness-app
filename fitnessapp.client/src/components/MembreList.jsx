// File: fitnessapp.client/src/components/MembreList.js
import React from 'react';

const membres = [
    { id: 1, name: 'Justine Alleron' },
    { id: 2, name: 'John Doe' },
    { id: 3, name: 'Jane Smith' }
];

const MembreList = () => {
    return (
        <div>
            <h2>Membres</h2>
            <ul>
                {membres.map(membre => (
                    <li key={membre.id}>{membre.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default MembreList;