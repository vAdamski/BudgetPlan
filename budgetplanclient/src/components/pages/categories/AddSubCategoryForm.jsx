import { useState } from 'react';
import PropTypes from 'prop-types';

const AddSubCategoryForm = ({ onAddSubCategory }) => {
    const [subCategoryName, setSubCategoryName] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onAddSubCategory(subCategoryName);
        setSubCategoryName(''); // Reset input
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Add subcategory"
                value={subCategoryName}
                onChange={(e) => setSubCategoryName(e.target.value)}
            />
            <button type="submit">Add</button>
        </form>
    );
};

AddSubCategoryForm.propTypes = {
    onAddSubCategory: PropTypes.func.isRequired,
};

export default AddSubCategoryForm;