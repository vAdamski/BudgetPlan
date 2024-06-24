import { useState } from 'react';
import PropTypes from 'prop-types';
import useTransactionCategoriesApi from "../../../services/api/transactionCategories.jsx";

const AddSubCategoryForm = ({ mainCategoryId, handleAction }) => {
    const {addTransactionCategory} = useTransactionCategoriesApi();

    const [subCategoryName, setSubCategoryName] = useState('');
    const thisMainCategoryId = mainCategoryId;

    const handleAddSubCategory = async () => {
        event.preventDefault();
        try {
            await addTransactionCategory({
                OverTransactionCategoryId: thisMainCategoryId,
                CategoryName: subCategoryName,
            });
            // Refresh categories
            handleAction();
            setSubCategoryName('');
        } catch (error) {
            console.error('Error adding transaction category:', error);
        }
    };


    return (
        <form onSubmit={handleAddSubCategory}>
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
    mainCategoryId: PropTypes.string.isRequired,
    handleAction: PropTypes.func.isRequired,
};

export default AddSubCategoryForm;