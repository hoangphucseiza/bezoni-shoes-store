const host = "https://localhost:7197";

export const postDataAPI = async (url, body, token) => {
  try {
    const data = await $fetch(`${host}/api/${url}`, {
      method: "POST",
      headers: {
        Authorization: `Bearer ${token}`,
      },
      body: body,
    });

    return { data, error: null };
  } catch (error) {
    return { data: null, error: error.response._data };
  }
};

export const getDataAPI = async (url, token) => {
  try {
    const data = await $fetch(`${host}/api/${url}`, {
      method: "GET",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    return { data, error: null };
  } catch (error) {
    return { data: null, error: error.response._data };
  }
};

export const putDataAPI = async (url, body, token) => {
  try {
    const data = await $fetch(`${host}/api/${url}`, {
      method: "PUT",
      headers: {
        Authorization: `Bearer ${token}`,
      },
      body: body,
    });

    return { data, error: null };
  } catch (error) {
    return { data: null, error: error.response._data };
  }
};

export const deleteDataAPI = async (url, token) => {
  try {
    const data = await $fetch(`${host}/api/${url}`, {
      method: "DELETE",
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    return { data, error: null };
  } catch (error) {
    return { data: null, error: error.response._data };
  }
};
