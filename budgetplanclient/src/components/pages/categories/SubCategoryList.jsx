import PropTypes from 'prop-types';
import AddSubCategoryForm from './AddSubCategoryForm';

const SubCategoryList = ({ subCategories, mainCategoryId, onAddSubCategory }) => {
    return (
        <ul>
            {subCategories.map(subCategory => (
                <li key={subCategory.id}>{subCategory.transactionCategoryName}</li>
            ))}
            <li>
                <AddSubCategoryForm onAddSubCategory={(subCategoryName) => onAddSubCategory(mainCategoryId, subCategoryName)} />
            </li>
        </ul>
    );
};

SubCategoryList.propTypes = {
    subCategories: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        transactionCategoryName: PropTypes.string.isRequired
    })).isRequired,
    mainCategoryId: PropTypes.number.isRequired,
    onAddSubCategory: PropTypes.func.isRequired,
};

export default SubCategoryList;