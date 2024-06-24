import PropTypes from 'prop-types';
import AddSubCategoryForm from './AddSubCategoryForm';

const SubCategoryList = ({ subCategories, mainCategoryId, handleAction }) => {
    return (
        <ul>
            {subCategories.map(subCategory => (
                <li key={subCategory.id}>{subCategory.transactionCategoryName}</li>
            ))}
            <li>
                <AddSubCategoryForm mainCategoryId={mainCategoryId} handleAction={handleAction} />
            </li>
        </ul>
    );
};

SubCategoryList.propTypes = {
    subCategories: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.string.isRequired,
        transactionCategoryName: PropTypes.string.isRequired
    })).isRequired,
    mainCategoryId: PropTypes.string.isRequired,
    handleAction: PropTypes.func.isRequired,
};

export default SubCategoryList;