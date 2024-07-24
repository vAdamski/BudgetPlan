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
            <div className={'input-group input-group-sm'}>
                <input type="text" className="form-control" value={subCategoryName}
                       onChange={(e) => setSubCategoryName(e.target.value)}/>
                <button className="btn btn-outline-success" type="submit">+</button>
            </div>
        </form>
);
};

AddSubCategoryForm.propTypes = {
    mainCategoryId: PropTypes.string.isRequired,
    handleAction: PropTypes.func.isRequired,
};

export default AddSubCategoryForm;