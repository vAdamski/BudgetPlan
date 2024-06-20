import { useState } from 'react';
import PropTypes from 'prop-types';

const AddCategoryForm = ({ onAddCategory }) => {
    const [categoryName, setCategoryName] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onAddCategory(categoryName);
        setCategoryName(''); // Reset input
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Add category"
                value={categoryName}
                onChange={(e) => setCategoryName(e.target.value)}
            />
            <button type="submit">Add</button>
        </form>
    );
};

AddCategoryForm.propTypes = {
    onAddCategory: PropTypes.func.isRequired,
};

export default AddCategoryForm;