/* Copyright 2010-2015 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.IO;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace MongoDB.Bson.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializer for Int16s.
    /// </summary>
    public class Int16Serializer : StructSerializerBase<short>, IRepresentationConfigurable<Int16Serializer>, IRepresentationConverterConfigurable<Int16Serializer>
    {
        // private fields
        private readonly BsonType _representation;
        private readonly RepresentationConverter _converter;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Int16Serializer"/> class.
        /// </summary>
        public Int16Serializer()
            : this(BsonType.Int32)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int16Serializer"/> class.
        /// </summary>
        /// <param name="representation">The representation.</param>
        public Int16Serializer(BsonType representation)
            : this(representation, new RepresentationConverter(false, false))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int16Serializer"/> class.
        /// </summary>
        /// <param name="representation">The representation.</param>
        /// <param name="converter">The converter.</param>
        public Int16Serializer(BsonType representation, RepresentationConverter converter)
        {
            switch (representation)
            {
                case BsonType.Decimal128:
                case BsonType.Double:
                case BsonType.Int32:
                case BsonType.Int64:
                case BsonType.String:
                    break;

                default:
                    var message = string.Format("{0} is not a valid representation for an Int16Serializer.", representation);
                    throw new ArgumentException(message);
            }

            _representation = representation;
            _converter = converter;
        }

        // public properties
        /// <summary>
        /// Gets the converter.
        /// </summary>
        /// <value>
        /// The converter.
        /// </value>
        public RepresentationConverter Converter
        {
            get { return _converter; }
        }

        /// <summary>
        /// Gets the representation.
        /// </summary>
        /// <value>
        /// The representation.
        /// </value>
        public BsonType Representation
        {
            get { return _representation; }
        }

        // public methods
        /// <summary>
        /// Deserializes a value.
        /// </summary>
        /// <param name="context">The deserialization context.</param>
        /// <param name="args">The deserialization args.</param>
        /// <returns>A deserialized value.</returns>
        public override short Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;

            var bsonType = bsonReader.GetCurrentBsonType();
            switch (bsonType)
            {
                case BsonType.Decimal128:
                    return _converter.ToInt16(bsonReader.ReadDecimal128());

                case BsonType.Double:
                    return _converter.ToInt16(bsonReader.ReadDouble());

                case BsonType.Int32:
                    return _converter.ToInt16(bsonReader.ReadInt32());

                case BsonType.Int64:
                    return _converter.ToInt16(bsonReader.ReadInt64());

                case BsonType.String:
                    return JsonConvert.ToInt16(bsonReader.ReadString());

                default:
                    throw CreateCannotDeserializeFromBsonTypeException(bsonType);
            }
        }

        /// <summary>
        /// Serializes a value.
        /// </summary>
        /// <param name="context">The serialization context.</param>
        /// <param name="args">The serialization args.</param>
        /// <param name="value">The object.</param>
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, short value)
        {
            var bsonWriter = context.Writer;

            switch (_representation)
            {
                case BsonType.Decimal128:
                    bsonWriter.WriteDecimal128(_converter.ToDecimal128(value));
                    break;

                case BsonType.Double:
                    bsonWriter.WriteDouble(_converter.ToDouble(value));
                    break;

                case BsonType.Int32:
                    bsonWriter.WriteInt32(_converter.ToInt32(value));
                    break;

                case BsonType.Int64:
                    bsonWriter.WriteInt64(_converter.ToInt64(value));
                    break;

                case BsonType.String:
                    bsonWriter.WriteString(JsonConvert.ToString(value));
                    break;

                default:
                    var message = string.Format("'{0}' is not a valid Int16 representation.", _representation);
                    throw new BsonSerializationException(message);
            }
        }

        /// <summary>
        /// Returns a serializer that has been reconfigured with the specified item serializer.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns>The reconfigured serializer.</returns>
        public Int16Serializer WithConverter(RepresentationConverter converter)
        {
            if (converter == _converter)
            {
                return this;
            }
            else
            {
                return new Int16Serializer(_representation, converter);
            }
        }

        /// <summary>
        /// Returns a serializer that has been reconfigured with the specified representation.
        /// </summary>
        /// <param name="representation">The representation.</param>
        /// <returns>The reconfigured serializer.</returns>
        public Int16Serializer WithRepresentation(BsonType representation)
        {
            if (representation == _representation)
            {
                return this;
            }
            else
            {
                return new Int16Serializer(representation, _converter);
            }
        }

        // explicit interface implementations
        IBsonSerializer IRepresentationConverterConfigurable.WithConverter(RepresentationConverter converter)
        {
            return WithConverter(converter);
        }

        IBsonSerializer IRepresentationConfigurable.WithRepresentation(BsonType representation)
        {
            return WithRepresentation(representation);
        }
    }
}
